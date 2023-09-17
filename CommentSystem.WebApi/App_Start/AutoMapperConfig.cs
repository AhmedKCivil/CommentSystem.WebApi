using AutoMapper;

namespace CommentSystem.WebApi
{
	public static class AutoMapperConfig
	{
		/// <summary>
		/// Initialise AutoMapper, set all mappings
		/// </summary>
		public static void Configure()
		{

			Mapper.Initialize(config =>
			{
				config.CreateMap<Data.CommentSystemDB.User, Entities.User>().ForMember(m => m.ID, o => o.MapFrom(s => s.ID));
				config.CreateMap<Data.CommentSystemDB.Comment, Entities.Comment>().ForMember(m => m.ID, o => o.MapFrom(s => s.ID));

				config.CreateMap<Entities.User, Data.CommentSystemDB.User>().ForMember(m => m.ID, o => o.MapFrom(s => s.ID));
				config.CreateMap<Entities.Comment, Data.CommentSystemDB.Comment>().ForMember(m => m.ID, o => o.MapFrom(s => s.ID));
			});
		}
	}
}