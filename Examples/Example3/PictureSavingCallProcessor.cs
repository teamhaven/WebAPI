using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamHaven.WebApi.Client;
using TeamHaven.WebApi.Models;

namespace Example3
{
	public class PictureSavingCallProcessor
	{
		TeamHavenClient api;

		public PictureSavingCallProcessor(TeamHavenClient api)
		{
			this.api = api;
		}

		// Must return TRUE to indicate that the call was successfully processed
		public async Task<bool> Process(IntegrationEvent integrationEvent)
		{
			// We know we're only called when Calls are saved, so the ObjectID will be the Call ID
			int callID = integrationEvent.Object.ObjectID;

			var manifest = await api.GetCallQuestionnaireManifest(callID);
			var answers = await api.GetCallAnswers(callID);

			var call = await api.GetCall(callID);
			var target = await api.GetTarget(call.ProjectID.Value, call.TargetID.Value);

			// Identify the Picture Answers by the fact they will have a non-null Picture property
			var pictureAnswers = from a in answers where a.Picture != null select a;

			Console.WriteLine("The answers for Call ID {0}, visiting {1} were saved", callID, target.Name);

			foreach (var pictureAnswer in pictureAnswers)
			{
				// Figure out which Question and Item this Picture is for
				var question = (from q in manifest.Questions where q.QuestionID == pictureAnswer.QuestionID select q).Single();
				var item = (from i in manifest.Items where i.ItemID == pictureAnswer.ItemID select i).SingleOrDefault() ?? new QuestionnaireItem { Caption = "(No item)" };

				Console.WriteLine("Picture {0} is the answer to {1} for {2}", pictureAnswer.Picture, question.Caption, item.Caption);

				// Download the Picture's contents from the server
				var bytes = await api.GetPicture(pictureAnswer.Picture.Value);
				Console.WriteLine("Downloaded picture ({0}KB)", bytes.Length / 1024);

				// Construct a filename
				var filename = String.Format("{0}_{1}_{2}_{3}.jpg", target.Name, call.ActualStart.Value.ToShortDateString().Replace("/", "-"), question.Caption, item.Caption);

				// Save the Picture locally
				System.IO.File.WriteAllBytes(filename, bytes);
			}

			return true;
		}
	}
}
