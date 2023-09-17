using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentSystem.Data.CommentSystemDB
{
	class DBIntialiser : CreateDatabaseIfNotExists<CommentSystemDB>
	{
		protected override void Seed(CommentSystemDB context)
		{
			base.Seed(context);
		}
	}
}
