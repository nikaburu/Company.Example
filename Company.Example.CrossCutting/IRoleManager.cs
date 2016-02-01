using System.Collections.Generic;

namespace Company.Example.CrossCutting
{
	public interface IRoleManager
	{
		bool IsGlobalActionAllowed(string userName, GlobalActionType actionType);
		bool IsProjectActionAllowed(string userName, int projectId, ProjectActionType actionType);
	}
}
