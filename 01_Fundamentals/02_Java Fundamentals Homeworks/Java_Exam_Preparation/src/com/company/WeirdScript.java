package com.company;

import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 2.11.2015 ã..
 */
public class WeirdScript {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        Integer letter = Integer.parseInt(sc.nextLine())%52;
        Character ch='\0';
        if(letter>0&&letter<27) ch=(char)(letter+96);
        else if(letter>=27&&letter<52)ch=(char)(letter+38);
        else if(letter==0) ch='Z';
        String input = sc.nextLine();
        while(!input.equals("End")){
            Pattern pattern = Pattern.compile(String.format("%c%c(.+)%c%c",ch,ch,ch,ch));
            Matcher m = pattern.matcher(input);
            if(m.find()){
                System.out.println(m.group(1));
            }
            input=sc.nextLine();
        }
    }
}
