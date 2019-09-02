import java.text.DecimalFormat;
import java.util.Scanner;

public class EvenOddPositions {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());

        double oddSumm = 0;
        double oddMax = Integer.MIN_VALUE;
        double oddMin = Integer.MAX_VALUE;
        double evenSumm = 0;
        double evenMax = Integer.MIN_VALUE;
        double evenMin = Integer.MAX_VALUE;
        String no = "";

        for (int i = 1; i <= n; i++) {
            double num = Double.parseDouble(scanner.nextLine());

            if (i % 2 == 1) {
                oddSumm += num;
                if (oddMax < num) {
                    oddMax = num;
                    if (oddMin > num) {
                        oddMin = num;
                    }
                }
            }
            if (i % 2 == 0) {
                evenSumm += num;
                if (evenMax < num) {
                    evenMax = num;
                    if (evenMin > num) {
                        evenMin = num;
                    }
                }
            }
        }
        DecimalFormat df = new DecimalFormat("#.##");
        System.out.printf("OddSum=%s\n", df.format(oddSumm));
        if (oddMin == Integer.MAX_VALUE) {
            System.out.println("OddMin=No,\n");
        } else {
            System.out.printf("OddMin=%s,\n", df.format(oddMin));
        }
        if (oddMax == Integer.MIN_VALUE) {
            System.out.println("OddMax=No,");
        } else {
            System.out.printf("OddMax=%s,\n", df.format(oddMax));
        }
        System.out.printf("EvenSum=%s\n", df.format(evenSumm));
        if (evenMin == Integer.MAX_VALUE) {
            System.out.println("EvenMin=No,\n");
        } else {
            System.out.printf("EvenMin=%s,\n", df.format(evenMin));
        }
        if (oddMax == Integer.MIN_VALUE) {
            System.out.println("EvenMax=No,");
        } else {
            System.out.printf("EvenMax=%s,\n", df.format(evenMax));
        }
    }
}