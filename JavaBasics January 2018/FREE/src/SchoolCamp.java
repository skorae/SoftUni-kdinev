import java.util.Scanner;

public class SchoolCamp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String season = scanner.nextLine().toLowerCase();
        String gender = scanner.nextLine().toLowerCase();
        int students = Integer.parseInt(scanner.nextLine());
        int nights = Integer.parseInt(scanner.nextLine());
        String sport = "";
        double cost = 0;

        if (gender.equals("boys") || gender.equals("girls")){
            if (season.equals("winter")){
                cost = (students * 9.60) * nights;
                if (gender.equals("girls")){
                    sport = "Gymnastics";
                }else if (gender.equals("boys")){
                    sport = "Judo";
                }
            }else if (season.equals("spring")){
                cost = (students * 7.20) * nights;
                if (gender.equals("girls")){
                    sport = "Athletics";
                }else if (gender.equals("boys")){
                    sport = "Tennis";
                }
            }else if (season.equals("summer")){
                cost = (students * 15.0) * nights;
                if (gender.equals("girls")){
                    sport = "Volleyball";
                }else if (gender.equals("boys")){
                    sport = "Football";
                }
            }
        }else if (gender.equals("mixed")){
            if (season.equals("winter")){
                cost = (students * 10.0) * nights;
                sport = "Ski";
            }else if (season.equals("spring")) {
                cost = (students * 9.50) * nights;
                sport = "Cycling";
            }else if (season.equals("summer")){
                cost = (students * 20) * nights;
                sport = "Swimming";
            }
        }
        if (students >= 10 && students < 20){
            cost = cost * 0.95;
        }else if (students >= 20 && students < 50){
            cost = cost * 0.85;
        }else if (students >= 50){
            cost = cost * 0.50;
        }
        System.out.printf("%s %.2f lv.", sport, cost);
    }
}
