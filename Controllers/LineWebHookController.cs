using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace isRock.Template
{
    public class LineWebHookController : isRock.LineBot.LineWebHookControllerBase
    {
        [Route("api/LineBotWebHook")]
        [HttpPost]
        public IActionResult POST()
        {
            var AdminUserId = "👉____replace_with_AdminUserId";

            try
            {
                //設定ChannelAccessToken
                this.ChannelAccessToken = "👉____replace_with_ChannelAccessToken";
                //配合Line Verify
                if (ReceivedMessage == null || ReceivedMessage.events == null || ReceivedMessage.events.Count() <= 0 ||
                    ReceivedMessage.events.FirstOrDefault().replyToken == "00000000000000000000000000000000") return Ok();
                //取得Line Event
                foreach (var LineEvent in this.ReceivedMessage.events)
                {
                    var responseMsg = "";
                    //準備回覆訊息
                    if (LineEvent.type.ToLower() == "message" && LineEvent.message.type == "text")
                    {
                        responseMsg = $"你說了: {LineEvent.message.text}";
                        if (LineEvent.message.mention != null && LineEvent.message.mention.mentionees != null && LineEvent.message.mention.mentionees.Count() > 0)
                        {
                            responseMsg += "\n有用戶被提到:";
                            foreach (var mention in LineEvent.message.mention.mentionees)
                            {
                                responseMsg += $"\n  {(string.IsNullOrEmpty(mention.userId) ? "ALL" : mention.userId)}...被提及。";
                                if (mention.isSelf) responseMsg += "(此帳號為 bot 本身)";
                            }
                        }
                    }
                    else if (LineEvent.type.ToLower() == "message")
                        responseMsg = $"收到 event : {LineEvent.type} type: {LineEvent.message.type} ";
                    else
                        responseMsg = $"收到 event : {LineEvent.type} ";
                    //回覆訊息
                    this.ReplyMessage(LineEvent.replyToken, responseMsg);
                }
                //response OK
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(AdminUserId, "發生錯誤:\n" + ex.Message);
                //response OK
                return Ok();
            }
        }
    }
}