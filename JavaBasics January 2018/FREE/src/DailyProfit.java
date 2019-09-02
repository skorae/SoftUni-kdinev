import java.util.Scanner;

public class DailyProfit {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int workDays = Integer.parseInt(scanner.nextLine());
        double moneyPerDay = Double.parseDouble(scanner.nextLine());
        double exchangeUSDtoBGN = Double.parseDouble(scanner.nextLine());

        double montlySalary = workDays * moneyPerDay;
        double yearlySalary = montlySalary * 12;
        double bonus = montlySalary * 2.5;
        double income = yearlySalary + bonus;
        double tax = income * 0.25;
        double total = (income - tax) * exchangeUSDtoBGN;
        double end = total / 365;

        System.out.printf("%.2f", end);


    }
}
