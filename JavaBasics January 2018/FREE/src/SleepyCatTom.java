import java.util.Scanner;

public class SleepyCatTom {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int restDays = Integer.parseInt(scanner.nextLine());

        int workdDays = 365 - restDays;
        int workPlayTime = workdDays * 63;
        int restPlaytime = restDays * 127;
        int totalPlaytime = workPlayTime + restPlaytime;
        int time = 0;

        if (totalPlaytime <= 30000) {
            time = 30000 - totalPlaytime;
            int hours = time / 60;
            int minutes = time % 60;
            System.out.printf("Tom sleeps well%n%d hours and %d minutes less for play", hours, minutes);

        } else {
            time = totalPlaytime - 30000;
            int hours = time / 60;
            int minutes = time % 60;
            System.out.printf("Tom will run away%n%d hours and %d minutes more for play", hours, minutes);

        }
    }
}
