# Push Notification Android Sample using Parse

This example demostrates how to send push notifications using Parse and receive them on your Android Xamarin Application.

Please check the following instructions to be able to test the sample correctly:

### Google Console Developer Instructions

1. [Create a Google Console Developer Project](https://console.developers.google.com/project)

2. Enable Google Cloud Messaging

  ![Enable Google Cloud Messaging 1](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_1.png)

  ![Enable Google Cloud Messaging 2](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_2.png)

3. Create a Server Key

  ![Enable Google Cloud Messaging 3](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_3.png)

  ![Enable Google Cloud Messaging 4](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_4.png)

4. Get the API Key

  ![Enable Google Cloud Messaging 5](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_5.png)

5. Get the Project Number id (This is the GCM sender id number)

  ![Enable Google Cloud Messaging 6](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/gcm_config_6.png)
  
----------
  
### Parse Instructions

1. [Create a Parse Project](https://parse.com/apps)

2. Make sure REST Push is enabled 

 ![Parse Push Config 1](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_config_1.png)
 
3. On GCM Push Credentials:
  * Paste your project number id on Sender Id field
  * Paste your GCM Server Api Key on API Key field
  
 ![Parse Push Config 2](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_config_2.png)
 
----------

### PushNotificationSample Project Instructions

1. Get Parse Application ID and REST API Key

 ![Parse Keys](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_keys.png)
 
2. Replace the constants in Constants.cs
  ```
   //TODO: Replace string parameter with your Android SENDER ID
   public const string GcmSenderId ="YOUR SENDER ID";

   //TODO: Replace string parameter with your Parse Application ID
   public const string ParseApplicationId ="YOUR PARSE APPLICATION ID";

   //TODO: Replace string parameter with your Parse Rest API Key
   public const string ParseRestApiKey ="YOUR PARSE REST API KEY";
```

----------

### Test Push Instructions

1. Go to Push section on your Parse Application

2. Click on Send Push

  ![Parse Push](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_1.png)

3. Leave the default settings

  ![Parse Push](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_2.png)

4. Write your push message

  ![Parse Push](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_3.png)

5. Click on Send now on the bottom of the page

  ![Parse Push](https://raw.githubusercontent.com/CrossGeeks/Xamarin.Samples/master/Xamarin.Android/Images/parse_push_4.png)




 
