import java.util.Scanner;

public class SoftUniCamp {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        double car = 0;
        double microBus = 0;
        double smallBus = 0;
        double bigBus = 0;
        double train = 0;
        double everyBody = 0;

        for (int i = 1; i <= n; i++) {
            int people = Integer.parseInt(scanner.nextLine());

            if (people <= 5) {
                car += people;
            }else if (people <= 12) {
                microBus += people;
            }else if (people <= 25) {
                smallBus += people;
            }else if (people <= 40) {
                bigBus += people;
            }else if (people > 40) {
                train += people;
            }

        }
        everyBody = car + microBus + smallBus + bigBus + train;

        double travelByCar = car / everyBody * 100;
        double travelByMicroBus =microBus / everyBody * 100;
        double travelBySmallBus = smallBus / everyBody * 100;
        double travelByBigBus = bigBus / everyBody * 100;
        double travelByTrain = train / everyBody * 100;

        System.out.printf("%.2f%%\n", travelByCar);
        System.out.printf("%.2f%%\n", travelByMicroBus);
        System.out.printf("%.2f%%\n", travelBySmallBus);
        System.out.printf("%.2f%%\n", travelByBigBus);
        System.out.printf("%.2f%%\n", travelByTrain);

    }
}
