import java.util.Scanner;

public class Cups {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int cupsMust = Integer.parseInt(scanner.nextLine());
        int workersCount = Integer.parseInt(scanner.nextLine());
        int workDays = Integer.parseInt(scanner.nextLine());

        double time = (workDays * 8) * workersCount;
        double cupsMade = Math.floor(time / 5);
        double moneyMade = cupsMade * 4.20;
        double moneyNeeded = cupsMust * 4.20;
        double diff = Math.abs(moneyMade - moneyNeeded);

        if (cupsMust <= cupsMade){
            System.out.printf("%.2f extra money", diff);
        }else{
            System.out.printf("Losses: %.2f", diff);
        }

    }
}
