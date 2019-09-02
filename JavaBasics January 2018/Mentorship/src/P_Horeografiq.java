import java.util.Scanner;

public class P_Horeografiq {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int steps = Integer.parseInt(scanner.nextLine());
        int dancers = Integer.parseInt(scanner.nextLine());
        int days = Integer.parseInt(scanner.nextLine());

        double allStepsPerDay = Math.ceil((steps * 1.0 / days) / steps * 100);
        double stepsPerDancer = allStepsPerDay / dancers;

        if (allStepsPerDay > 13){
            System.out.printf("They will not succeed in that goal! Required %.2f%% steps to be learned per day.", stepsPerDancer);
        }else{
            System.out.printf("Yes, they will succeed in that goal! %.2f%%", stepsPerDancer);
        }
        System.out.println();
    }
}
