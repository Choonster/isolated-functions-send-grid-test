# Azure Functions Isolated SendGrid Test

- Open project in Visual Studio
- Rename local.settings.json.template to local.settings.json
- Set `AzureWebJobsSendGridApiKey` to a valid SendGrid API key
- Set `FromEmail` and `FromName` to a valid email address/name that SendGrid can send from
- Set `ToEmail` and `ToName` to your own email address/name
- Run the project
- Observe that the following exception is logged each time the function is executed:
```
[2023-12-26T09:42:00.063Z] Executed 'Functions.TestSendGrid' (Failed, Id=28a88f22-744b-4668-9113-4f3370158afa, Duration=222ms)
[2023-12-26T09:42:00.064Z] System.Private.CoreLib: Exception while executing function: Functions.TestSendGrid. Microsoft.Azure.WebJobs.Extensions.SendGrid: A 'To' address must be specified for the message.
```
