import java.util.Scanner;

public class Styrofoam {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double budget = Double.parseDouble(scanner.nextLine());
        double houseSize = Double.parseDouble(scanner.nextLine());
        double windowCount = Integer.parseInt(scanner.nextLine()) * 2.4;
        double stiroporPerMetSquear = Double.parseDouble(scanner.nextLine());
        double pricePerPackage = Double.parseDouble(scanner.nextLine());

        double totalSize = (houseSize - windowCount) * 1.10;
        double stiroporNeeded = Math.ceil(totalSize / stiroporPerMetSquear) * pricePerPackage;
        double diff = Math.abs(stiroporNeeded - budget);

        if (budget >=stiroporNeeded){
            System.out.printf("Spent: %.2f\n Left: %.2f", stiroporNeeded, diff);
        }else{
            System.out.printf("Need more: %.2f", diff);
        }
    }
}
