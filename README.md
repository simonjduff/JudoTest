# JudoTest
This a technical test prior to an interview.

This was implemented using a kind of Outside-In style TDD. Rather than an end-to-end test, I ensure that the main class makes all the steps that it needs to make in order to succeed, in separate tests, mocking out the preceding steps. This is an approach I'm experimenting with.

The test cases are not exhaustive (due to time constraints). There will likely be edge cases that fail (eg UTF8 characters, some special characters).

The git checkins are relatively granular, so TDD flow should be somewhat visible.
