using System;
using CommentSystem.Services.Interfaces;

namespace CommentSystem.Services
{
	public class DateTimeService : IDateTimeService
	{
		public DateTime Now
		{
			get { return DateTime.Now; }
		}

		public DateTime UtcNow
		{
			get { return DateTime.UtcNow; }
		}
	}
}
