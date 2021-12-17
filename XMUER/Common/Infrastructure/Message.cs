﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XMUER.Common.Infrastructure
{
    [Serializable]
    public class Message
    {
        private ExpandoObject _result;

        /// <summary>
        /// 初始化消息实例
        /// </summary>
        public Message()
        {
            _result = new ExpandoObject();

            this.Code = 0;
            this.Msg = string.Empty;
        }

        /// <summary>
        /// 初始化消息实例
        /// </summary>
        /// <param name="code">状态代码</param>
        /// <param name="msg">提示信息</param>
        public Message(int code, string msg) : this()
        {
            this.Code = code;
            this.Msg = msg;
        }

        /// <summary>
        /// 状态代码 1~10 保留，11~100 数据层错误，101以上 业务错误
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 成功标识，状态代码 Code=0 时，判断为 True.
        /// </summary>
        public bool Success => this.Code == 0;


        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 附带结果对象字典
        /// </summary>
        public dynamic Result
        {
            get { return _result; }
            set { _result = value; }
        }


        /// <summary>
        /// 是否包含结果对象
        /// </summary>
        /// <param name="name">对象名称</param>
        /// <returns>True 包含；False 不包含</returns>
        public bool HasResult(string name)
        {
            var resultDict = this._result as IDictionary<string, object>;
            return resultDict.ContainsKey(name);
        }

        /// <summary>
        /// 设置状态代码和提示信息。
        /// </summary>
        /// <param name="code">状态代码</param>
        /// <param name="msg">提示信息</param>
        public void SetMsg(int code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        /// <summary>
        /// 转化 Message 对象为 JSON 字符串。
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
