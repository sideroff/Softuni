package com.company;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 4.11.2015 ã..
 */
public class WeightLifting {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer n = Integer.parseInt(sc.nextLine());
        TreeMap<String,TreeMap<String,Long>> players = new TreeMap<>();
        Pattern pattern = Pattern.compile("(\\w+)\\s(\\w+)\\s(\\d+)");
        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();
            Matcher m = pattern.matcher(input);
            if(m.find()){
                String name = m.group(1);
                String exercise = m.group(2);
                Long kg = Long.parseLong(m.group(3));
                if(!players.containsKey(name)){
                    players.put(name,new TreeMap<String, Long>(){{put(exercise,kg);}});
                }
                else if(!players.get(name).containsKey(exercise)){
                    players.get(name).put(exercise,kg);
                }
                else {
                    players.get(name).put(exercise,players.get(name).get(exercise)+kg);
                }
            }
        }
        for (String name : players.keySet()) {
            String output = String.format("%s :",name);
            for (String exercise : players.get(name).keySet()) {
                output+=String.format(" %s - %d kg,",exercise,players.get(name).get(exercise));
            }
            System.out.println(output.substring(0,output.length()-1));
        }
    }
}
