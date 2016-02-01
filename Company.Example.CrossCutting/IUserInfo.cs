namespace Company.Example.CrossCutting
{
    public interface IUserInfo
    {
	    string UserName { get; }
	    bool IsAuthenticated { get; }
    }
}
