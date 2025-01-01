# Line Webhook Example

這是一個 Line Webhook 範例，使用新版(2.14.40)的 SDK 展示提及 (mention) 功能。

## 功能

此 Webhook 主要功能如下：
1. 接收來自 Line 的訊息事件。
2. 回覆用戶所發送的文字訊息。
3. 檢查訊息中是否有提及其他用戶，並在回覆中顯示被提及的用戶 ID。
4. 如果提及的是 bot 本身，會在回覆中標註。

## 使用方法

1. 將 `LineWebHookController.cs` 中的 `ChannelAccessToken` 和 `AdminUserId` 替換為您的 Line Bot 資訊。
2. 部署此專案到您的伺服器。
3. 設定 Line 官方帳號的 Webhook URL 為您的伺服器地址。

## 範例

當用戶發送訊息 "Hello" 並使用 @ 提及其他用戶時，bot 會回覆：
```
你說了: Hello
有用戶被提到:
  U1234567890...被提及。
```
如果提及的是 bot 本身，會回覆：
```
你說了: Hello
有用戶被提到:
  U1234567890...被提及。(此帳號為 bot 本身)
```

欽此，沒了，不用謝。