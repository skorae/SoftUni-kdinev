import java.util.Scanner;

public class Pets {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        int foodLeft = Integer.parseInt(scanner.nextLine());
        double dogFoodPerDay = Double.parseDouble(scanner.nextLine());
        double catFoodPerDay = Double.parseDouble(scanner.nextLine());
        double tutleFoodPerDay = Double.parseDouble(scanner.nextLine());
        double diff = 0;

        double totalFoodNeeded = (dogFoodPerDay + catFoodPerDay + (tutleFoodPerDay / 1000)) * (days * 1.0);

        if (foodLeft >= totalFoodNeeded){
            diff = foodLeft - totalFoodNeeded;
            System.out.printf("%.0f kilos of food left.", Math.floor(diff));
        }else{
            diff = totalFoodNeeded - foodLeft;
            System.out.printf("%.0f more kilos of food are needed.", Math.ceil(diff));
        }
    }
}
