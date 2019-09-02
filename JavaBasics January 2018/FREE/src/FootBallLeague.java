import java.util.Scanner;

public class FootBallLeague {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int capacity = Integer.parseInt(scanner.nextLine());
        int fan = Integer.parseInt(scanner.nextLine());
        int secA = 0;
        int secB = 0;
        int secV = 0;
        int secG = 0;

        for (int i = 0; i < fan; i++) {
            String sector = scanner.nextLine().toLowerCase();

            if (sector.equals("a")){
                secA+=1;
            }else if (sector.equals("b")){
                secB+=1;
            }else if (sector.equals("v")) {
                secV += 1;
            }else if (sector.equals("g")) {
                secG += 1;
            }
        }

        System.out.printf("%.2f%%\n%.2f%%\n%.2f%%\n%.2f%%\n%.2f%%", (secA * 1.0 / fan) * 100,(secB * 1.0 / fan) * 100,
                (secV * 1.0 / fan) * 100,(secG * 1.0 / fan) * 100, (fan * 1.0 / capacity) * 100);

    }
}
