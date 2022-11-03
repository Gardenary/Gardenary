package com.gardenary;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.ConfigurationPropertiesScan;
import org.springframework.data.jpa.repository.config.EnableJpaAuditing;
import org.springframework.scheduling.annotation.EnableScheduling;

@ConfigurationPropertiesScan
@SpringBootApplication
@EnableJpaAuditing
@EnableScheduling
public class GardenaryBeApplication {

	public static void main(String[] args) {
		SpringApplication.run(GardenaryBeApplication.class, args);
	}

}
