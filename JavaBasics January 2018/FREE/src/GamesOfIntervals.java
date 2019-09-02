import java.util.Scanner;

public class GamesOfIntervals {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int count = 0;
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;
        double points = 0;
        double statistic = 0;
        double statistic1 = 0;
        double statistic2 = 0;
        double statistic3 = 0;
        double statistic4 = 0;
        double statistic5 = 0;

        for (int i = 1; i <= n; i++) {
            int num = Integer.parseInt(scanner.nextLine());

            if (num < 0 || num > 50) {
                count++;
                points /= 2;
            } else if (num < 10) {
                count1++;
                points += num * 0.2;
            } else if (num < 20) {
                count2++;
                points += num * 0.3;
            } else if (num < 30) {
                count3++;
                points += num * 0.4;
            } else if (num < 40) {
                count4++;
                points += 50;
            } else if (num <= 50) {
                count5++;
                points += 100;
            }
            statistic = (count * 1.0) / n * 100;
            statistic1 = (count1 * 1.0) / n * 100;
            statistic2 = (count2 * 1.0) / n * 100;
            statistic3 = (count3 * 1.0) / n * 100;
            statistic4 = (count4 * 1.0) / n * 100;
            statistic5 = (count5 * 1.0) / n * 100;

        }
        System.out.printf("%.2f\n", points);
        System.out.printf("From 0 to 9: %.2f%%\n", statistic1);
        System.out.printf("From 10 to 19: %.2f%%\n", statistic2);
        System.out.printf("From 20 to 29: %.2f%%\n", statistic3);
        System.out.printf("From 30 to 39: %.2f%%\n", statistic4);
        System.out.printf("From 40 to 50: %.2f%%\n", statistic5);
        System.out.printf("Invalid numbers: %.2f%%\n", statistic);
    }
}