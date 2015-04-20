package intentservices;

import com.example.androidserverversie2.HostActivity;
import com.google.android.gms.gcm.GoogleCloudMessaging;

import android.app.IntentService;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.v4.app.NotificationCompat;

/**
 * The MediaService processes the Google Cloudmessage and sends a local broadcast
 * @author Valentijn
 *
 */
public class MediaService extends IntentService
{
	public static final int NOTIFICATION_ID = 1;
	public static final String NEW_SONG_ACTION = "com.example.androidserverversie2.SONGACTION";
	public static final String SONG_NAME = "songName";
	public static final String SONG_PATH = "songPath";
	private NotificationManager mNotificationManager;
	NotificationCompat.Builder builder;
	
	public MediaService() 
	{
		super("MediaService");
		// TODO Auto-generated constructor stub
	}

	@Override
	protected void onHandleIntent(Intent intent) 
	{
		Bundle extras = intent.getExtras();
		GoogleCloudMessaging gcm = GoogleCloudMessaging.getInstance(this);
		
		String messageType = gcm.getMessageType(intent);//Get the message
		
		if(!extras.isEmpty())
		{
			if(GoogleCloudMessaging.MESSAGE_TYPE_SEND_ERROR.equals(messageType))
			{
				sendNotification("Send error: " + extras.toString());
				
			}
			else if(GoogleCloudMessaging.MESSAGE_TYPE_DELETED.equals(messageType))
			{
				sendNotification("Deleted messages on server: " + extras.toString());
			}
			else if(GoogleCloudMessaging.MESSAGE_TYPE_MESSAGE.equals(messageType))
			{
				//Make a notification to indicate that the message has been processed.
				sendNotification("Play time!");
				sendNotification("Data: " + extras.toString());
				
				String songName = extras.getString("SONGNAME");
				String songPath = extras.getString("SONGPATH");
				
				//Make a intent, save the song name and song path in it. 
				Intent notifyHost = new Intent();
				notifyHost.setAction(NEW_SONG_ACTION);
				notifyHost.addCategory(Intent.CATEGORY_DEFAULT);
				notifyHost.putExtra(SONG_NAME, songName);
				notifyHost.putExtra(SONG_PATH, songPath);
				//Send the intent as a broadcast
				sendBroadcast(notifyHost);
			}
				
		}
	}
	/**
	 * This function makes a notification that displays a message.
	 * @param msg
	 */
	private void sendNotification(String msg)
	{
		mNotificationManager = (NotificationManager)
				this.getSystemService(Context.NOTIFICATION_SERVICE);
		
		PendingIntent contentIntent = PendingIntent.getActivity(this, 0,
				new Intent(this, HostActivity.class), 0);
		
		NotificationCompat.Builder mBuilder = new NotificationCompat.Builder(this)
			.setContentTitle("Audiobox Notification")
			.setStyle(new NotificationCompat.BigTextStyle()
			.bigText(msg))
			.setContentText(msg);
		
		mBuilder.setContentIntent(contentIntent);
		mNotificationManager.notify(NOTIFICATION_ID, mBuilder.build());
	}

}
