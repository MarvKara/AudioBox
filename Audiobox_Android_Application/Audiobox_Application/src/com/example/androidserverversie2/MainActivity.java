package com.example.androidserverversie2;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.TextView;

public class MainActivity extends Activity
{

		
	/* Dit is de mainActivity van de app. In de mainActivity wordt het tab systeem gemaakt wat bestaat uit standaard
	 * code die geleverd in door de makers van de SDK. 
	 * Alegemeen gebruikte bronnen: 	http://www.vogella.com/articles/AndroidBackgroundProcessing/article.html.
	 * 									http://www.wikihow.com/Show-Alert-Dialog-in-Android
	 * 									http://www.mkyong.com/android/android-togglebutton-example/
	 * 									http://www.techotopia.com/index.php/A_Basic_Overview_of_Android_Threads_and_Thread_handlers
	 * 
	 */
	
	private Button clientButton;
	private Button hostButton;
	private String googleId;
	private TextView googleText;
	
	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		
		
		googleText = (TextView)findViewById(R.id.googleId);
		
		
		clientButton = (Button)findViewById(R.id.partyButton);
		hostButton = (Button)findViewById(R.id.hostButton);
		
		clientButton.setOnClickListener(new OnClickListener()
		{
			@Override
			public void onClick(View v) 
			{
				Intent client = new Intent(getBaseContext(), LoginActivity.class);
				startActivity(client);
			}
			
		});
		
		hostButton.setOnClickListener(new OnClickListener()
		{

			@Override
			public void onClick(View v) 
			{
				Intent host = new Intent(getBaseContext(), HostActivity.class); 
				startActivity(host);
			}
			
		});
	}
}
