package com.company;
import com.sun.corba.se.impl.encoding.OSFCodeSetRegistry;

import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 1.11.2015 ã..
 */
public class User_Logs {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        TreeMap<String,LinkedHashMap<String,Integer>> logs = new TreeMap<>();
        String input = sc.nextLine();
        while(!input.equals("end"))
        {
            Pattern pattern = Pattern.compile("IP=(\\S+).+user=(.+)");
            Matcher m = pattern.matcher(input);
            if(m.matches()){
                String ip = m.group(1);
                String username = m.group(2);
                if(!logs.containsKey(username)){                                // if it doesnt have username
                    logs.put(username,new LinkedHashMap<String,Integer>(){{put(ip,1);}});
                }
                else{                                                           //if it has username
                    if(!logs.get(username).containsKey(ip)){                    // doenst have ip
                        logs.get(username).put(ip,1);
                    }
                    else logs.get(username).put(ip,logs.get(username).get(ip)+1);
                }
            }
            input=sc.nextLine();
        }
        for (String username : logs.keySet()) {
            System.out.println(username+":");
            String line ="";
            for (String ip : logs.get(username).keySet()) {
                line+=String.format(" %s => %d,",ip,logs.get(username).get(ip));
            }
            System.out.println(line.substring(0,line.length()-1)+".");
        }
    }
}
