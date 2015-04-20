package fragments;

import java.io.File;

import networking.ConnectionManager;


import com.example.androidserverversie2.ClientActivity;
import com.example.androidserverversie2.R;
import android.os.Bundle;
import android.app.Activity;
import android.app.Fragment;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;

/**
 * Het filefragment zorgt voor het functioneren van de bestandsserver en -client.
 * @author Valentijn
 * @category Fragment
 * 
 */

public class UploadFragment extends Fragment 
{
	
	private Button resieveButton;//De knop voor het opvragen van het bestand van de server.
	
	@Override
	public View onCreateView(LayoutInflater inflater, ViewGroup container,
			Bundle savedInstanceState) 
	{
		View rootView = inflater.inflate(R.layout.activity_upload_fragment,
				container, false);
		
		return rootView;
	}
	
	@Override
	public void onActivityCreated(Bundle savedInstanceState) 
	{
		super.onActivityCreated(savedInstanceState);
		//Koppel de objecten.
		resieveButton = (Button)getView().findViewById(R.id.sendAudioFile);
		//De onClick functie voor de ontvangknop
		resieveButton.setOnClickListener(new View.OnClickListener() {
			
			@SuppressWarnings("deprecation")
			@Override
			public void onClick(View v) 
			{
				//Laat de gebruiker een bestand uit zoeken met zijn of haar filemanager. 
				//Als het bestand gekozen is dat wordt de methode "onActivityResult" aangeroepen.
				Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
	             intent.setType("file/*");//Laat de gebruiker elk bestandstype kiezen (txt, mp3, pdf, doc, enz).
	             startActivityForResult(intent,1000);
			}
		});
	}

	@Override
	public void onActivityResult(int requestCode, int resultCode, Intent data) 
	{
		//Als het bericht afkomstig van de ACTION_GET_CONTENT mag de onderstaande code uitgevoert worden.
		if(requestCode == 1000)
		{	
			String filePath = data.getData().getPath();//Kijk welk bestand de gebruiker heeft geselecteerd.
			
			//Contoleer 
			if(filePath != null || filePath != "")
			{
				Activity parent = getActivity();
				if(parent instanceof ClientActivity)
				{
					ConnectionManager connManager = new ConnectionManager(parent);
					connManager.uploadFile(new File(filePath));
					((ClientActivity) parent).hideUploadFrag();
				}
			}
		}
		super.onActivityResult(requestCode, resultCode, data);
	}

	
	
}
