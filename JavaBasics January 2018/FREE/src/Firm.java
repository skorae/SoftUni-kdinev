import java.util.Scanner;

public class Firm {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hoursNeeded = Integer.parseInt(scanner.nextLine());
        int daysNeeded = Integer.parseInt(scanner.nextLine());
        int overtimeWorkers = Integer.parseInt(scanner.nextLine());

        double trainingTime = (daysNeeded - (daysNeeded * 0.1)) * 8;
        double workersTime = (overtimeWorkers * 2) * daysNeeded;
        double totalWorkingTime = Math.floor(trainingTime + workersTime);
        double diff = Math.abs(totalWorkingTime - hoursNeeded);

        if (totalWorkingTime >= hoursNeeded){
            System.out.printf("Yes!%.0f hours left.", diff);
        }else{
            System.out.printf("Not enough time!%.0f hours needed.", diff);
        }


    }
}
