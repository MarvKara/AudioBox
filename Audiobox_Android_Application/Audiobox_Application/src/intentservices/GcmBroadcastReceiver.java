package intentservices;

import android.app.Activity;
import android.content.ComponentName;
import android.content.Context;
import android.content.Intent;
import android.support.v4.content.WakefulBroadcastReceiver;

/**
 * The GcmBroadcastReciever will be triggered when the phone receives a Google Cloudmessage and is registered in the Manifest
 * @author Valentijn
 *
 */

public class GcmBroadcastReceiver extends WakefulBroadcastReceiver
{

	@Override
	public void onReceive(Context context, Intent intent) 
	{
		ComponentName comp = new ComponentName(context.getPackageName(),
				MediaService.class.getName());
		//Start the MediaService
		startWakefulService(context, (intent.setComponent(comp)));
		setResultCode(Activity.RESULT_OK);
		
	}

}
