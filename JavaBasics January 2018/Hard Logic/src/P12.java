import java.util.Scanner;

public class P12 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        String year = scanner.nextLine();
        int p = Integer.parseInt(scanner.nextLine());// broi praznici v godinata
        int h = Integer.parseInt(scanner.nextLine());//broi praznici v koito patuva
        double weekendsInSofia = (48 - h) * 3.0 / 4;
        double holidayPlay = p * 2.0 / 3;
        double totalPlay = weekendsInSofia + holidayPlay + h;

        if (year.equals("normal")) {
            System.out.println(Math.floor(totalPlay));
        } else if (year.equals("leap")) {
            double playTime = totalPlay + (totalPlay * 0.15);
            System.out.println(Math.floor(playTime));
        }
    }
}
