
using Jst.Utils.Extension;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Jst.WebUtils.xRequest
{
    /// <summary>
    /// 使用方式：
    /// 1、在配置文件中配置AppId，AppSecret（客服消息需要公众号的微信id，配置ServiceWxId）
    /// 2、如果使用默认模板，需要配置模板Id（templateId）
    /// </summary>
    public class WxInterfaceRequest
    {

        #region 属性
        private static string AppId { get; set; }

        private static string AppSecret { get; set; }

        private static string _token;

        private static string WxServiceAccount { get; set; }

        private static DateTime TokenLastUpdateTime { get; set; }

        /// <summary>
        /// 模板Id
        /// </summary>
        private static string TemplateId { get; set; }

        #region token
        private static string AccessToken
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_token) || (DateTime.Now - TokenLastUpdateTime).TotalSeconds > 3600 * 2)
                {
                    try
                    {
                        _token = GetAccessToken();
                    }
                    catch (Exception)
                    {
                        _token = string.Empty;
                    }
                }

                return _token;
            }
        }

        public static string GetAccessToken()
        {
            string token = string.Empty;
            if (!string.IsNullOrEmpty(AppId) && !string.IsNullOrEmpty(AppSecret))
            {
                string tokenUrl = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId, AppSecret);
                System.Net.WebClient client = new System.Net.WebClient();
                string strJson = client.DownloadString(tokenUrl);
                Dictionary<string, object> dictionary = strJson.DeserializeJson<Dictionary<string, object>>();//JsonConvert.DeserializeObject<Dictionary<string, object>>(strJson);
                token = dictionary["access_token"].ToString();
                TokenLastUpdateTime = DateTime.Now;
            }
            return token;
        }
        #endregion
        #endregion

        static WxInterfaceRequest()
        {
            AppId = System.Configuration.ConfigurationManager.AppSettings["AppId"]; //ConfigBll.GetAppConfig("AppId");
            AppSecret = System.Configuration.ConfigurationManager.AppSettings["AppSecret"]; //ConfigBll.GetAppConfig("AppSecret");
            WxServiceAccount = System.Configuration.ConfigurationManager.AppSettings["ServiceWxId"];// ConfigBll.GetAppConfig("ServiceWxId");
            TemplateId = System.Configuration.ConfigurationManager.AppSettings["templateId"];// ConfigBll.GetAppConfig("templateId");
            string token = AccessToken;
        }

        /// <summary>
        /// 请求微信接口
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="param">参数（Get方式，传入null，参数以地址栏传递）</param>
        /// <param name="contenttype"></param>
        /// <param name="method">Post/Get</param>
        /// <returns></returns>
        public static string Request(string url, object param, string contenttype = "application/json;charset=utf-8", string method = "post")
        {
            string responseString = string.Empty;
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            request.ContentType = contenttype;
            request.Method = method;
            if (param != null)
            {
                using (Stream stream = request.GetRequestStream())
                {
                    string strJson = JsonConvert.SerializeObject(param);
                    byte[] bytes = Encoding.UTF8.GetBytes(strJson);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = request.GetResponse().GetResponseStream())
            {
                StreamReader reader = new StreamReader(response, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            return responseString;

        }

        /// <summary>
        /// 请求微信接口(Async方式增加吞吐量);
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="contenttype"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public async static Task<string> RequestAsync(string url, object param, string contenttype = "application/json;charset=utf-8", string method = "post")
        {
            string responseString = string.Empty;
            System.Net.WebRequest request = System.Net.WebRequest.Create(url);
            request.ContentType = contenttype;
            request.Method = method;
            if (param != null)
            {
                using (Stream stream = await request.GetRequestStreamAsync())
                {
                    string strJson = JsonConvert.SerializeObject(param);
                    byte[] bytes = Encoding.UTF8.GetBytes(strJson);
                  await  stream.WriteAsync(bytes, 0, bytes.Length);
                }
            }

            using (var response = (await request.GetResponseAsync()).GetResponseStream())
            {
                StreamReader reader = new StreamReader(response, Encoding.UTF8);
                responseString = reader.ReadToEnd();
            }
            return responseString;

        }

        /// <summary>
        /// 发送微信模板消息(UTF-8编码）
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="data">模板参数</param>
        /// <returns>微信服务器返回(UTF-8编码）</returns>
        public static string SendWxTemplateMsg(string openid, string templateid, string linkUrl, object data)
        {
            string response = string.Empty;

            if (openid.IsEmpty() || templateid.IsEmpty() || data == null) throw new ArgumentException("缺少参数");

            if (!string.IsNullOrWhiteSpace(WxServiceAccount) && !string.IsNullOrWhiteSpace(AccessToken))
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", AccessToken);
                dynamic param = new System.Dynamic.ExpandoObject();
                param.touser = openid;
                param.template_id = TemplateId;
                param.url = linkUrl;
                param.data = data;
                response = Request(url, param);
            }
            return response;
        }

        /// <summary>
        /// 发送微信模板消息(UTF-8编码）
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="data">模板参数</param>
        /// <returns>微信服务器返回(UTF-8编码）</returns>
        public async static Task<string> SendWxTemplateMsgAsync(string openid, string templateid, string linkUrl, object data)
        {
            string response = string.Empty;

            if (openid.IsEmpty() || templateid.IsEmpty() || data == null) throw new ArgumentException("缺少参数");

            if (!string.IsNullOrWhiteSpace(WxServiceAccount) && !string.IsNullOrWhiteSpace(AccessToken))
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", AccessToken);
                dynamic param = new System.Dynamic.ExpandoObject();
                param.touser = openid;
                param.template_id = TemplateId;
                param.url = linkUrl;
                param.data = data;
                response = await RequestAsync(url, param);
            }
            return response;
        }
        /// <summary>
        /// 使用默认的模板发送模板消息(UTF-8编码）
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="linkurl">链接</param>
        /// <param name="data">模板数据</param>
        /// <returns>微信服务器返回(UTF-8编码）</returns>
        public static string SendWxTemplateMsg(string openid, string linkurl, object data)
        {
            return SendWxTemplateMsg(openid, TemplateId, linkurl, data);
        }

        /// <summary>
        /// 使用默认的模板发送模板消息(UTF-8编码）
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="linkurl">链接</param>
        /// <param name="data">模板数据</param>
        /// <returns>微信服务器返回(UTF-8编码）</returns>
        public async static Task<string> SendWxTemplateMsgAsync(string openid, string linkurl, object data)
        {
            return await SendWxTemplateMsgAsync(openid, TemplateId, linkurl, data);
        }

        /// <summary>
        /// 发送客服文本消息
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="msg">消息内容</param>
        /// <param name="msgtype">消息类型</param>
        /// <returns></returns>
        public static string SendWxCustomerServiceTextMsg(string openid, string msg)
        {
            string response = string.Empty;
            if (!string.IsNullOrWhiteSpace(WxServiceAccount) && !string.IsNullOrWhiteSpace(AccessToken))
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", AccessToken);
                dynamic param = new System.Dynamic.ExpandoObject();
                param.touser = openid;
                param.msgtype = "text";
                param.text = new { content = msg };
                response = Request(url, param);
            }
            return response;
        }

        /// <summary>
        /// 发送客服文本消息
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="msg">消息内容</param>
        /// <param name="msgtype">消息类型</param>
        /// <returns></returns>
        public async static Task<string> SendWxCustomerServiceTextMsgAsync(string openid, string msg)
        {
            string response = string.Empty;
            if (!string.IsNullOrWhiteSpace(WxServiceAccount) && !string.IsNullOrWhiteSpace(AccessToken))
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", AccessToken);
                dynamic param = new System.Dynamic.ExpandoObject();
                param.touser = openid;
                param.msgtype = "text";
                param.text = new { content = msg };
                response = await RequestAsync(url, param);
            }
            return response;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static string GetWxUserInfo(string openid)
        {
            string response = string.Empty;
            if(openid.IsEmpty()) throw new ArgumentException("缺少参数","openid");
            if(!AccessToken.IsEmpty())
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN ",AccessToken,openid);
                response = Request(url, null, method: "get");
            }
            return response;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async static Task<string> GetWxUserInfoAsync(string openid)
        {
            string response = string.Empty;
            if (openid.IsEmpty()) throw new ArgumentException("缺少参数", "openid");
            if (!AccessToken.IsEmpty())
            {
                string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN ", AccessToken, openid);
                response = await RequestAsync(url, null, method: "get");
            }
            return response;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static WxOpenUserInfo GetWxOpenUserInfo(string openid)
        {
            return GetWxUserInfo(openid).DeserializeJson<WxOpenUserInfo>();
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public async static Task<WxOpenUserInfo> GetWxOpenUserInfoAsync(string openid)
        {
            return (await GetWxUserInfoAsync(openid)).DeserializeJson<WxOpenUserInfo>();
        }
    }

    public class WxOpenUserInfo
    {
        /// <summary>
        /// 用户是否订阅该公众号标识，值为0时，代表此用户没有关注该公众号，拉取不到其余信息。
        /// </summary>
        public string Subscribe { get; set; }

        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 用户的昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 用户的性别，值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 用户所在城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 用户所在国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 用户所在省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 用户的语言，简体中文为zh_CN
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 用户头像，最后一个数值代表正方形头像大小（有0、46、64、96、132数值可选，0代表640*640正方形头像），用户没有头像时该项为空。若用户更换头像，原有头像URL将失效。
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 用户关注时间，为时间戳。如果用户曾多次关注，则取最后关注时间
        /// </summary>
        public long Subscribe_Time { get; set; }

        /// <summary>
        /// 只有在用户将公众号绑定到微信开放平台帐号后，才会出现该字段。
        /// </summary>
        public string UnionId { get; set; }

        /// <summary>
        /// 公众号运营者对粉丝的备注，公众号运营者可在微信公众平台用户管理界面对粉丝添加备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 用户所在的分组ID（兼容旧的用户分组接口）
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        /// 用户被打上的标签ID列表
        /// </summary>
        public int[] TagId_List { get; set; }
    }

}
