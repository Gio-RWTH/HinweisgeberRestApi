using System.Text;

namespace HinweigeberRestApi.SharedModels
{
	public static class StringExtensions
	{
		public static T ParseEnum<T>(this string value)
		{
			return (T)Enum.Parse(typeof(T), value, true);
		}

		public static string ToConnectionString(this byte[] bdb)
		{
			string res = "";
			char[] chars = Encoding.Unicode.GetChars(bdb);
			string pconstr = "";
			for (int j = 0; j < chars.Length; j++)
			{
				pconstr += chars[j];
			}
			res = pconstr;
			return res;
		}

		public static string ToSplitKommaString(this List<int> ids)
		{
			return string.Join(',', ids);
		}
	}
}
