package com.company;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 14.11.2015 �..
 */
public class Srabsko_Unleashed {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        ArrayList<venue> venues = new ArrayList<>();
        while (!input.equals("End")) {
            Pattern pattern = Pattern.compile("(.+)\\s@(.+)\\s(\\d+)\\s(\\d+)");
            Matcher m = pattern.matcher(input);
            while (m.find()) {
                String name = m.group(1);
                String venue = m.group(2);
                Long ticketPrice = Long.parseLong(m.group(3));
                Long ticketCount = Long.parseLong(m.group(4));
                boolean hasFound = false;
                for (Srabsko_Unleashed.venue addedVenue : venues) {
                    if (addedVenue.name.equals(venue)) {
                        addedVenue.addSinger(name, ticketCount * ticketPrice);
                        hasFound = true;
                    }
                }
                if (!hasFound) {
                    Srabsko_Unleashed.venue newVenue = new venue(venue);
                    newVenue.addSinger(name, ticketCount * ticketPrice);
                    venues.add(newVenue);
                }
            }
            input = sc.nextLine();
        }
        for (venue venue : venues) {
            venue.singers.sort((singer1, singer2) -> singer1.compareTo(singer2));
            System.out.printf("%s\n", venue.name);
            for (singer singer : venue.singers) {
                System.out.printf("#  %s -> %d\n", singer.name, singer.money);
            }

        }
    }

    public static class venue {
        String name;
        ArrayList<singer> singers = new ArrayList<>();

        public venue(String name) {
            this.name = name;
        }

        public void addSinger(String singerName, Long money) {
            boolean hasFound = false;
            for (singer singer : this.singers) {
                if (singer.name.equals(singerName)) {
                    singer.addMoney(money);
                    hasFound = true;
                    break;
                }
            }
            if (!hasFound) {
                Srabsko_Unleashed.singer singer1 = new singer(singerName, money);
                this.singers.add(singer1);
            }
        }
    }

    public static class singer implements Comparable<singer> {
        String name;
        Long money;

        public singer(String name, Long money) {
            this.name = name;
            this.money = money;
        }

        public void addMoney(Long money) {
            this.money += money;
        }

        @Override
        public int compareTo(singer o) {
            return Long.compare(o.money, this.money);
        }
    }
}

