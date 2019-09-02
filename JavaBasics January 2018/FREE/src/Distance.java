import java.util.Scanner;

public class Distance {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int firstSpeed = Integer.parseInt(scanner.nextLine());
        int firstTime = Integer.parseInt(scanner.nextLine());
        int secondTime = Integer.parseInt(scanner.nextLine());
        int thirdTime = Integer.parseInt(scanner.nextLine());
        double secondSpeed = firstSpeed + firstSpeed * 0.1;
        double thirdSpeed = secondSpeed - secondSpeed * 0.05;

        double S1 = firstSpeed * (firstTime * 1.0 / 60);
        double S2 = secondSpeed * (secondTime * 1.0 / 60);
        double S3 = thirdSpeed * (thirdTime * 1.0 / 60);

        double total = S1 + S2 + S3;

        System.out.printf("%.2f", total);

    }
}
