using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Web;

namespace Company.Example.Infrastructure.DependecyResolution
{
	public class HttpContextLifetimeManager<T> : LifetimeManager
	{

		public const string ContextKey = "_ContextKey";

		public Dictionary<string, object> Dictionary
		{
			get
			{
				Dictionary<string, object> dictionary = (Dictionary<string, object>)HttpContext.Current.Items[ContextKey];
				if (dictionary == null)
				{
					dictionary = new Dictionary<string, object>();
					HttpContext.Current.Items[ContextKey] = dictionary;
				}
				return dictionary;
			}
		}

		public string Key
		{
			get { return typeof(T).AssemblyQualifiedName; }
		}


		public override object GetValue()
		{
			if (Dictionary.ContainsKey(Key))
			{
				return Dictionary[Key];
			}
			return null;
		}

		public override void RemoveValue()
		{
			Dictionary.Remove(Key);
		}

		public override void SetValue(object newValue)
		{
			if (Dictionary.ContainsKey(Key))
			{
				Dictionary[Key] = newValue;
			}
			Dictionary.Add(Key, newValue);
		}


	}
}