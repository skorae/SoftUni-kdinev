import java.util.Scanner;

public class TruckDriver {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String season = scanner.nextLine().toLowerCase();
        double km = Double.parseDouble(scanner.nextLine());
        double salary = 0;

        if (km <= 5000){
            if (season.equals("spring") || season.equals("autumn")){
                salary = (km * 0.75) * 4;
            }else if (season.equals("summer")){
                salary = (km * 0.90) * 4;
            }else if (season.equals("winter")){
                salary = (km * 1.05) * 4;
            }
        }else if (km <= 10000){
            if (season.equals("spring") || season.equals("autumn")){
                salary = (km * 0.95) * 4;
            }else if (season.equals("summer")){
                salary = (km * 1.10) * 4;
            }else if (season.equals("winter")){
                salary = (km * 1.25) * 4;
            }
        }else{
            salary = (km * 1.45) * 4;
        }
        double total = salary * 0.90;

        System.out.printf("%.2f", total);
    }
}
