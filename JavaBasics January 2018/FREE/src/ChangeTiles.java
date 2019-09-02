import java.util.Scanner;

public class ChangeTiles {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double moneyCollected = Double.parseDouble(scanner.nextLine());
        double wightFloor = Double.parseDouble(scanner.nextLine());
        double lenghtFloor = Double.parseDouble(scanner.nextLine());
        double triangleSide = Double.parseDouble(scanner.nextLine());
        double higthTriangle = Double.parseDouble(scanner.nextLine());
        double oneSlabPrice = Double.parseDouble(scanner.nextLine());
        double workerMoney = Double.parseDouble(scanner.nextLine());

        double floor = wightFloor * lenghtFloor;
        double slab = triangleSide * higthTriangle / 2;
        double neededSlabs = Math.ceil(floor / slab) + 5;
        double moneyForSlabs = neededSlabs * oneSlabPrice;
        double allMoneyNeeded = moneyForSlabs + workerMoney;
        double diff = Math.abs(allMoneyNeeded - moneyCollected);

        if (allMoneyNeeded <= moneyCollected){
            System.out.printf("%.2f lv left.", diff);
        }else{
            System.out.printf("You'll need %.2f lv more.", diff);
        }
    }
}
