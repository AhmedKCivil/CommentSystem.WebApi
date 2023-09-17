using System;

namespace CommentSystem.Services.Interfaces
{
	public interface IDateTimeService
	{
		DateTime Now { get; }
		DateTime UtcNow { get; }

	}
}
