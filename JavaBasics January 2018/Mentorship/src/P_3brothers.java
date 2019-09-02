import java.util.Scanner;

public class P_3brothers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double timeA = Double.parseDouble(scanner.nextLine());
        double timeB = Double.parseDouble(scanner.nextLine());
        double timeC = Double.parseDouble(scanner.nextLine());
        double timeD = Double.parseDouble(scanner.nextLine());

        double timeForCleaning = 1 / (1 / timeA + 1 / timeB + 1 / timeC);
        timeForCleaning = timeForCleaning + timeForCleaning * 15 / 100;

        System.out.printf("Cleaning time: %.2f", timeForCleaning);

        if (timeForCleaning > timeD){
            System.out.printf("No, there isn&#39;t a surprise - shortage of time -> %.0f hours.", Math.ceil(timeForCleaning - timeD));
        }else{
            System.out.printf("Yes, there is a surprise - time left -> %.0f hours.", Math.floor(timeD - timeForCleaning));
        }

    }
}
