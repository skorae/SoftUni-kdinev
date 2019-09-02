import java.util.Scanner;

public class BikeRace {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int juniors = Integer.parseInt(scanner.nextLine());
        int seniors = Integer.parseInt(scanner.nextLine());
        String track = scanner.nextLine();

        double jEntryFee = 0;
        double sEntryFee = 0;
        double allFee = 0;

        if (track.equalsIgnoreCase("trail")) {
            jEntryFee = juniors * 5.50;
            sEntryFee = seniors * 7;
        } else if (track.equalsIgnoreCase("cross-country")) {
            if ((juniors + seniors) >= 50) {
                jEntryFee = juniors * 8 - ((juniors * 8) * 0.25);
                sEntryFee = seniors * 9.50 - ((seniors * 9.50) * 0.25);
            }else{
                jEntryFee = juniors * 8;
                sEntryFee = seniors * 9.50;
            }
        } else if (track.equalsIgnoreCase("downhill")) {
            jEntryFee = juniors * 12.25;
            sEntryFee = seniors * 13.75;
        } else if (track.equalsIgnoreCase("road")) {
            jEntryFee = juniors * 20;
            sEntryFee = seniors * 21.50;
        }
        allFee = jEntryFee + sEntryFee;
        double expense = allFee * 0.05;
        double total = allFee - expense;

        System.out.printf("%.2f", total);
    }
}