import java.util.Scanner;

public class WorkHours {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int hoursNeeded = Integer.parseInt(scanner.nextLine());
        int workers = Integer.parseInt(scanner.nextLine());
        int workDays = Integer.parseInt(scanner.nextLine());

        int total = workers * (workDays * 8);
        int diff = Math.abs(total - hoursNeeded);

        if (total >= hoursNeeded){
            System.out.printf("%d hours left\n", diff);
        }else{
            int penalties = diff * workDays;
            System.out.printf("%d overtime\nPenalties: %d", diff, penalties);
        }
    }
}
