package com.company;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 6.11.2015 ã..
 */
public class Aggregator {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer n = Integer.parseInt(sc.nextLine());
        TreeMap<String,TreeMap<String,Integer>> map = new TreeMap<>();
        for (int i = 0; i < n; i++) {
            String input = sc.nextLine();
            Pattern pattern = Pattern.compile("(\\S+)\\s(\\w+)\\s(\\d+)");
            Matcher matcher = pattern.matcher(input);

            if(matcher.find()){
                String ip = matcher.group(1);
                String name = matcher.group(2);
                Integer duration = Integer.parseInt(matcher.group(3));

                if(!map.containsKey(name)){
                    map.put(name,new TreeMap<String,Integer>(){{put(ip,duration);}});
                }
                else {
                    if(!map.get(name).containsKey(ip)) map.get(name).put(ip,duration);
                    else map.get(name).put(ip,map.get(name).get(ip)+duration);
                }
            }
        }
        for (String name : map.keySet()) {
            System.out.printf("%s: ",name);
            Integer duration = 0;
            for (String ip : map.get(name).keySet()) {
                duration+=map.get(name).get(ip);
            }
            System.out.printf("%d [",duration);
            String sb = "";
            for (String ip : map.get(name).keySet()) {
                sb+=String.format("%s, ",ip);
            }
            System.out.println(sb.substring(0,sb.length()-2)+"]");
        }
    }
}
