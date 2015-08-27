namespace TeamHaven.WebApi.Models
{
	public enum Role
	{
		/// <summary>
		/// User is an Administrator
		/// </summary>
		Admin = 1,

		/// <summary>
		/// User is a Collector
		/// </summary>
		Collector = 2,

		/// <summary>
		/// User is a Project Manager
		/// </summary>
		Manager = 3,

		/// <summary>
		/// User is a Client
		/// </summary>
		Client = 4,

		/// <summary>
		/// User is a Field Manager
		/// </summary>
		Coordinator = 5
	}
}
