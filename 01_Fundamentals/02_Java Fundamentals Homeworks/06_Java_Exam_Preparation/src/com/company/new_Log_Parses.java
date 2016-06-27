package javaExam;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * Created by name on 15.11.2015  ..
 */

class Project{
    public String name;
    public ArrayList<String> criticals = new ArrayList<>();
    public ArrayList<String> warnings = new ArrayList<>();

    public Project(String name) {
        this.name = name;
    }
    public int compareTo(Project other) {
        int i = -Integer.compare(criticals.size() + warnings.size(), other.criticals.size() + other.warnings.size());
        if (i != 0) return i;

        return name.compareTo(other.name);
    }
}

public class new_Log_Parses {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String line = console.nextLine();
        ArrayList<Project> projects = new ArrayList<>();
        while(!line.equals("END")){
            List<String> lineParts = new ArrayList<>();
            Matcher litersMather = Pattern.compile("(?<=\\[\").*?(?=\"\\])")
                    .matcher(line);
            while (litersMather.find()) {
                lineParts.add(litersMather.group());
            }
            int index = -1;
            for (int i = 0; i < projects.size(); i++) {
                if(projects.get(i).name.equals(lineParts.get(0))){
                    index = i;
                    break;
                }
            }
            if(index == -1){
                projects.add(new Project(lineParts.get(0)));
                index = projects.size() - 1;
            }
            if(lineParts.get(1).equals("Critical")){
                projects.get(index).criticals.add(lineParts.get(2));
            }
            else if(lineParts.get(1).equals("Warning")){
                projects.get(index).warnings.add(lineParts.get(2));
            }
            line = console.nextLine();
        }
        projects.stream()
                .sorted((project1, project2) ->
                        project1.compareTo(project2))
                .forEach(project -> {
                    System.out.println(project.name + ":");
                    System.out.println("Total Errors: " + ((int) project.warnings.size() + (int) project.criticals.size()));
                    System.out.println("Critical: " + project.criticals.size());
                    System.out.println("Warnings: " + project.warnings.size());
                    System.out.println("Critical Messages:");
                    if(project.criticals.size() != 0){
                        project.criticals.stream()
                                .sorted((message1, message2) -> {
                                    int i = Integer.compare(message1.length(), message2.length());
                                    if(i != 0) return i;

                                    return message1.compareTo(message2);
                                })
                                .forEach(message -> System.out.println("--->" + message));
                    }
                    else{
                        System.out.println("--->None");
                    }
                    System.out.println("Warning Messages:");
                    if(project.warnings.size() != 0) {
                        project.warnings.stream()
                                .sorted((message1, message2) -> {
                                    int i = Integer.compare(message1.length(), message2.length());
                                    if (i != 0) return i;

                                    return message1.compareTo(message2);
                                })
                                .forEach(message -> System.out.println("--->" + message));
                    }
                    else{
                        System.out.println("--->None");
                    }
                    System.out.println();
                });
    }
}