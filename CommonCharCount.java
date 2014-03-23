//This program prints the common characters in two given strings and their count 
//Eg: input: 
//apple 
//papaya  
//output:
//a 1
//p 2

import java.io.InputStreamReader;
import java.io.*;
import java.util.HashMap;
import java.util.Iterator;

public class CommonCharCount {

    public static void main(String[] args) throws IOException{

              BufferedReader br = new BufferedReader(new InputStreamReader(System.in));
              String string1 = br.readLine();
        String string2=br.readLine();
        HashMap<Character,Integer> hashmap_string1=new HashMap<Character, Integer>();
        HashMap<Character,Integer> hashmap_string2=new HashMap<Character, Integer>();
        for(char c : string1.toCharArray())
        {
            if(!hashmap_string1.containsKey(c))
            {
                hashmap_string1.put(c,1);
            }
            else
            {
               hashmap_string1.put(c, hashmap_string1.get(c)+1);
            }
        }
        for(char c : string2.toCharArray())
        {
            if(!hashmap_string2.containsKey(c))
            {
                hashmap_string2.put(c,1);
            }
            else
            {
                hashmap_string2.put(c, hashmap_string2.get(c)+1);
            }
        }
        Iterator iter = hashmap_string1.keySet().iterator();
        while(iter.hasNext())
        {
            Character c = (Character)iter.next();
            if(hashmap_string2.containsKey(c))
            {
                System.out.println(c+"   "+(hashmap_string1.get(c)>hashmap_string2.get(c)?hashmap_string2.get(c):hashmap_string1.get(c)).toString());
            }
        }

    }
}