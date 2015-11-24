package com.company;

import java.util.ArrayList;
import java.util.Scanner;

/**
 * Created by Siderov on 14.11.2015 ã..
 */
public class Olympics_Are_Coming {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input1 = sc.nextLine().trim();
        ArrayList<country> countries = new ArrayList<>();
        while(!input1.equals("report")){
            String input = input1.replaceAll("\\s+"," ");
            String[] arg = input.split("\\s*\\|\\s*");
            String athlete = arg[0];
            String country = arg[1];
            boolean hasFound = false;
            for (country addedCountry : countries) {
                if(addedCountry.name.equals(country)){
                    addedCountry.addAthlete(athlete);
                    hasFound=true;
                }
            }
            if(!hasFound){
                Olympics_Are_Coming.country newCountry = new country(country);
                newCountry.addAthlete(athlete);
                countries.add(newCountry);
            }
            input1=sc.nextLine().trim();
        }
        countries.sort((country1,country2) -> country1.compareTo(country2));
        for (country country : countries) {
            System.out.printf("%s (%d participants): %d wins\n",country.name,country.athletes.size(),country.totalWins);
        }

    }
    public static class country implements Comparable<country>{
        String name;
        Long totalWins = 0L;
        ArrayList<athlete> athletes = new ArrayList<>();
        public country(String name){
            this.name = name;
        }
        public void addAthlete(String athleteName){
            boolean hasFound=false;
            for (athlete athlete : this.athletes) {
                if(athlete.name.equals(athleteName)){
                    hasFound=true;
                    this.totalWins++;
                    break;
                }
            }
            if(!hasFound){
                athlete newAthlete = new athlete(athleteName);
                this.athletes.add(newAthlete);
                this.totalWins++;
            }
        }

        @Override
        public int compareTo(country o) {
            return Long.compare(o.totalWins,this.totalWins);
        }
    }
    public static class athlete{
        String name;
        public athlete(String name){
            this.name=name;
        }
    }
}
