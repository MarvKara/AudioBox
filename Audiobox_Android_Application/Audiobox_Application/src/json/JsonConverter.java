package json;

import java.util.ArrayList;
import java.util.List;

import models.Song;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.util.Log;

/**
 * The JsonConverter is an static class for converting Json. 
 * @author Valentijn
 *
 */

public class JsonConverter 
{
	//JSON node names
	private static final String SONG_ID = "songId";
	private static final String SONG_NAME = "songName";
	private static final String LIKES = "likes";
	private static final String DISLIKES = "disLikes";
	
	//Using synchronized to prevent threads from blocking each other.	
	public static synchronized List<Song> convertStringToList(String jsonString)
	{
		//Convert the string to json and convert the json to a list
		return convertJsonArrayToList(convertStringToJsonArray(jsonString));
	}
	
	/**
	 * Converts the jsonString to a JSON array
	 * @param jsonString
	 * @return A JSONArray object
	 */
	private static JSONArray convertStringToJsonArray(String jsonString)
	{
		JSONArray jsonArray;
		
		try //Try to convert the jsonString to and JSONObject
		{
			jsonArray = new JSONArray(jsonString);
		}
		catch(JSONException ex)
		{
			throw new RuntimeException(ex);//Conversion failed
		}
		return jsonArray;
	}
	/**
	 * This function converts a JSONArray object to an Arraylist
	 * @param jsonArray
	 * @return Playlist as an Arraylist
	 */
	private static List<Song> convertJsonArrayToList(JSONArray jsonArray)
	{
		List<Song> playlist = new  ArrayList<Song>();
		
		//Get each Song and store it in a Song object
		for(int counter = 0;counter < jsonArray.length();counter++)
		{
			try 
			{
				JSONObject item = jsonArray.getJSONObject(counter);
				
				Song newSong = new Song(
						(int) Integer.parseInt(item.get(SONG_ID).toString()), 		//Songid
						(String) item.get(SONG_NAME),								//Song name
						(int) Integer.parseInt(item.get(LIKES).toString()),			//Likes
						(int) Integer.parseInt(item.get(DISLIKES).toString())		//Dislikes
						);
				
				playlist.add(newSong);//Add the Song object to the playlist.
			} 
			catch (JSONException ex) 
			{
				Log.e("JsonConverter", "Error: can't convert string to JSON");
				throw new RuntimeException(ex);
			}
			catch (NumberFormatException ex)
			{
				Log.e("JsonConverter", "Error: can't convert string to number");
				throw new RuntimeException(ex);
			}
		}
		return playlist;
		
	}
	
	
}
