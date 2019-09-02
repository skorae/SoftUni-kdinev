import java.util.Scanner;

public class ThreeBrothers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double timeA = Double.parseDouble(scanner.nextLine());
        double timeB = Double.parseDouble(scanner.nextLine());
        double timeC = Double.parseDouble(scanner.nextLine());
        double timeD = Double.parseDouble(scanner.nextLine());

        double cleaning = (1 / (1/timeA + 1/timeB + 1/timeC)) * 1.15;
        double diff = Math.abs(timeD - cleaning);

        System.out.printf("Cleaning time: %.2f\n", cleaning);

        if (timeD >= cleaning){
            System.out.printf("Yes, there is a surprise - time left -> %.0f hours.", Math.floor(diff));
        }else{
            System.out.printf("No, there isn't a surprise - shortage of time -> %.0f hours.", Math.ceil(diff));
        }
    }
}
