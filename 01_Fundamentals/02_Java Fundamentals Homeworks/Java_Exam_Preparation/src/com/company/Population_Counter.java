package com.company;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.TreeMap;

public class Population_Counter {
    public static void main(String[] args) {

        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        ArrayList<Country> countries = new ArrayList<>();

        while(!input.equals("report")) {

            String[] arg = input.split("\\|");
            String country = arg[1];
            String city = arg[0];
            Long population = Long.parseLong(arg[2]);
            boolean hasFound = false;
            for (Country addedCountry: countries) {
                if(addedCountry.name.equals(country)){
                    hasFound=true;
                    addedCountry.addCity(city,population);
                    break;
                }
            }
            if(!hasFound){
                Country newCountry = new Country(country);
                newCountry.addCity(city,population);
                countries.add(newCountry);
            }
            input = sc.nextLine();
        }

        countries.sort((country1,country2) -> country1.compareTo(country2));
        for (Country country : countries) {
            System.out.printf("%s (total population: %d)\n",country.name,country.totalPopulation);
            country.cities.sort((city1,city2) -> city1.compareTo(city2));
            for (City city : country.cities) {
                System.out.printf("=>%s: %d\n", city.name, city.population);
            }
        }
    }
    public static class Country implements Comparable<Country>{
        String name;
        Long totalPopulation;
        ArrayList<City> cities = new ArrayList<>();
        public  Country(String countryName){
            this.name = countryName;
            this.totalPopulation=0L;
        }
        public void addCity(String name, Long population) {

            City s = new City(name, population);
            this.totalPopulation += population;
            this.cities.add(s);
        }

        @Override
        public int compareTo(Country o) {
            return Long.compare(o.totalPopulation,this.totalPopulation);
        }
    }
    public static class City implements Comparable<City>{
        String name;
        Long population;
        public City(String name, Long population){
            this.name = name;
            this.population=population;
        }

        @Override
        public int compareTo(City o) {
            return Long.compare(o.population, this.population);
        }
    }
}