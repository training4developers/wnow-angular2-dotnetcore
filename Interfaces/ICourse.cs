using System;
using System.Collections.Generic;

namespace Training4Developers.Interfaces { 
		public interface ICourse {
		int Id { get; set; }
		string Title { get; set; }
		string Description { get; set; }
		IEnumerable<ITag> Topics { get; }
		Uri SourceCodeUrl { get; set; }
		Uri ResourceFilesUrl { get; set; }
		IEnumerable<ILink> ResourceLinks { get; }
		ICourse AppendTopic(ITag topic);
		ICourse RemoveTopic(int topicId);
		ICourse AppendResourceLink(ILink resourceLink);
		ICourse RemoveResourceLink(int resourceLinkId);
	}
}