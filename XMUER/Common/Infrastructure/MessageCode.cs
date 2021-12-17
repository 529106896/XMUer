using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace XMUER.Common.Infrastructure
{
	public enum MessageCode
	{
		[Description("成功")]
		OK = 0,

		[Description("服务器内部错误")]
		INTERNAL_SERVER_ERR = 500,

		[Description("数据不能为空")]
		DATA_NOT_EMPTY = 601,

		[Description("上传文件为空")]
		UPLOAD_FILE_EMPTY = 602,

		[Description("你还未登入")]
		NOT_LOGGED_IN = 603
	}

	//获取描述
	static class EnumExtensions
	{
		public static string GetDescription(this Enum val)
		{
			var field = val.GetType().GetField(val.ToString());
			var customAttribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
			if (customAttribute == null) { return val.ToString(); }
			else { return ((DescriptionAttribute)customAttribute).Description; }
		}
	}
}
