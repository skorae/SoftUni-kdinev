import java.util.Scanner;

public class P_Scholarship {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        double income = Double.parseDouble(scanner.nextLine());
        double averageScore = Double.parseDouble(scanner.nextLine());
        double minSalary = Double.parseDouble(scanner.nextLine());


        if (income > minSalary) {
            if (averageScore >= 5.5) {
                double scholarship = averageScore * 25;
                System.out.printf("You get a scholarship for excellent results %.0f BGN", Math.floor(scholarship));
            } else {
                System.out.printf("You cannot get a scholarship!");
            }
        } else if (averageScore >= 4.5 && averageScore < 5.5) {
            double scholarship = minSalary * 35 / 100;
            System.out.printf("You get a Social scholarship %.0f BGN", Math.floor(scholarship));
        } else if (averageScore >= 5.5) {
            double scholarshipSocial = minSalary * 35 / 100;
            double scholarshipScore = averageScore * 25;

            if (scholarshipScore > scholarshipSocial) {
                System.out.printf("You get a scholarship for excellent results %.0f BGN", Math.floor(scholarshipScore));
            } else {
                System.out.printf("you get a Social scholarship %.0f BGN", Math.floor(scholarshipSocial));
            }
        } else {
            System.out.println("You cannot get a scholarship!");
        }
    }
}

