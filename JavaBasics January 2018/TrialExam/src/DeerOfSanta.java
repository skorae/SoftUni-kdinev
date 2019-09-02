import java.util.Scanner;

public class DeerOfSanta {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int days = Integer.parseInt(scanner.nextLine());
        int foodKilos = Integer.parseInt(scanner.nextLine());
        double foodForDeer1 = Double.parseDouble(scanner.nextLine());
        double foodForDeer2 = Double.parseDouble(scanner.nextLine());
        double foodForDeer3 = Double.parseDouble(scanner.nextLine());

        double deer1 = foodForDeer1 * days;
        double deer2 = foodForDeer2 * days;
        double deer3 = foodForDeer3 * days;
        double totalNeeded = deer1 + deer2 + deer3;
        double diff = Math.abs(totalNeeded - foodKilos);

        if (totalNeeded <= foodKilos){
            System.out.printf("%.0f kilos of food left.", Math.floor(diff));
        }else{
            System.out.printf("%.0f more kilos of food are needed.", Math.ceil(diff));
        }
    }
}
