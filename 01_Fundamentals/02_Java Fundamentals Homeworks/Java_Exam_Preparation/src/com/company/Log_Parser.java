package com.company;

import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by Siderov on 15.11.2015 ã..
 */
public class Log_Parser {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String input = sc.nextLine();
        ArrayList<Project> projects = new ArrayList<>();
        while(!input.equals("END")){
            Pattern pattern = Pattern.compile("\\{\"Project\": \\[\"(.*)\"\\], \"Type\": \\[\"(\\w*)\"], \"Message\": \\[\"(.*)\"]}");
            Matcher m = pattern.matcher(input);
            while(m.find()){
                String pName = m.group(1);
                String pType= m.group(2);
                String pMessege = m.group(3);
                boolean hasFound = false;
                for (Project project : projects) {
                    if(project.name.equals(pName)){
                        project.addError(pType);
                        project.errors.get(project.errors.size()-1).addMessege(pMessege);
                        hasFound = true;
                        break;
                    }
                }
                if(!hasFound){
                    Project newProject = new Project(pName);
                    newProject.addError(pType);
                    newProject.errors.get(newProject.errors.size()-1).addMessege(pMessege);
                    projects.add(newProject);
                }
            }
            input= sc.nextLine();
        }

        for (Project project : projects) {
            project.errors.sort((error1,error2) -> error2.compareTo(error1));
        }
        projects.sort((project1,project2) -> project1.compareTo(project2));
        String sb = "";
        for (Project project : projects) {
            sb+=String.format("\n%s:\n", project.name);
            sb+=String.format("Total Errors: %d\n",project.errors.size());
            Long criticals =0L;
            String critialString = "";
            String warningString = "";
            Long warnings = 0L;
            for (Error error : project.errors) {
                if(error.name.equals("Critical")) {
                    critialString+= String.format("--->%s\n",error.message);
                    criticals++;

                }
                else if(error.name.equals("Warning")) {
                    warningString+= String.format("--->%s\n",error.message);

                    warnings++;
                }
            }
            if(critialString.equals("")) critialString="--->None\n";
            if(warningString.equals("")) warningString="--->None\n";


            sb+=String.format("Critical: %d\n",criticals);
            sb+=String.format("Warnings: %d\n", warnings);
            sb+=String.format("Critical Messages:\n%s",critialString);
            sb+=String.format("Warning Messages:\n%s",warningString);
            System.out.printf(sb.trim());
        }
    }
    public static class Project implements Comparable<Project>{
        String name;
        ArrayList<Error> errors = new ArrayList<>();
        public Project(String name){
            this.name = name;
        }
        public void addError(String name){
            Error newError = new Error(name);
            this.errors.add(newError);
        }

        @Override
        public int compareTo(Project o) {
            return Integer.compare(o.errors.size(),this.errors.size());
        }
    }
    public static class Error implements Comparable<Error>{
        String name;
        String message;
        public Error(String name){
            this.name = name;
        }
        public void addMessege(String message){
            this.message=message;
        }

        @Override
        public int compareTo(Error o) {
            if(o.message.length()==this.message.length()){
                return o.message.compareTo(this.message);
            }
            return Integer.compare(o.message.length(),this.message.length());
        }
    }
}
